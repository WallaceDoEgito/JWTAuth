using BarotraumaJWT.DTOs;
using BarotraumaJWT.Models;

namespace BarotraumaJWT.Interfaces;

public interface ICharacterService
{
    public Task<Characters?> CreateCharacter(UserRequestCharacterCreation request, String userId);
    public Task<List<Characters>?> GetAllCharacters(String userId);
    public Task<String?> DeleteCharacterById(String characterId, String userId);
}