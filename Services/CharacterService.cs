using System.Security.Cryptography.Xml;
using BarotraumaJWT.Data;
using BarotraumaJWT.DTOs;
using BarotraumaJWT.Enums;
using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace BarotraumaJWT.Services;

public class CharacterService(AppDbContext dbContext) : ICharacterService
{
    public async Task<Characters?> CreateCharacter(UserRequestCharacterCreation request, string userId)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);
        if (user is null) return null;

        try
        {
            if (!Enum.TryParse<Roles>(request.Profission, out var profission)) return null;
            Characters newChar = new Characters(request.Name, profission);
            newChar.CreatorId = new Guid(userId);
            await dbContext.Characters.AddAsync(newChar);
            await dbContext.SaveChangesAsync();
            return newChar;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }


    }

    public async Task<List<Characters>?> GetAllCharacters(string userId)
    {
        var user =  await dbContext.Characters.Where(c => c.CreatorId.ToString() == userId).ToListAsync();
        return user;
    }

    public async Task<string?> DeleteCharacterById(string characterId, string userId)
    {
        Characters? characterToDelete = await dbContext.Characters.FirstOrDefaultAsync(e => e.Id.ToString() == characterId);
        if (characterToDelete is null) return null;
        if (characterToDelete.CreatorId.ToString() != userId) return null;
        String name = characterToDelete.Name;
        dbContext.Characters.Remove(characterToDelete);
        await dbContext.SaveChangesAsync();
        return name;
    }
}