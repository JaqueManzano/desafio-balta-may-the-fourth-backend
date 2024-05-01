﻿using desafio_backend.Services.Interfaces;
using desafio_backend.ViewModels;
using desafio_shared.Data;
using Microsoft.EntityFrameworkCore;

namespace desafio_backend.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly AppDbContext _context;

        public CharacterService(AppDbContext context)
        {
            _context = context;
        }
        
        public CharacterViewModel GetCharacter(int id)
        {
            var result = _context.Characters.Select(character =>
             new CharacterViewModel(
                character.Name,
                character.Height,
                character.Weight,
                character.HairColor,
                character.SkinColor,
                character.EyeColor,
                character.BirthYear,
                character.Gender,
                new BasicInfoViewModel { Id = character.Planet.Id, Name = character.Planet.Name },
                character.Movies.Select(mv => new BasicMovieInfoViewModel
                   {
                       Id = mv.Id,
                       Title = mv.Title
                   }).ToList()
            )).AsNoTracking().FirstOrDefault();

            return result;
        }
        

        public List<CharacterViewModel> GetCharacters()
        {
            var result = _context.Characters.Select(character => 
            new CharacterViewModel(
                character.Name,
                character.Height,
                character.Weight,
                character.HairColor,
                character.SkinColor,
                character.EyeColor,
                character.BirthYear,
                character.Gender,
                new BasicInfoViewModel { Id = character.Planet.Id, Name = character.Planet.Name },
                character.Movies.Select(mv => new BasicMovieInfoViewModel
                {
                    Id = mv.Id,
                    Title = mv.Title
                }).ToList()
            )).AsNoTracking().ToList();

            return result;
        }
    }
}
