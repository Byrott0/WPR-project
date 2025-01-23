﻿using Microsoft.EntityFrameworkCore;
using WPR_project.Data;
using WPR_project.Models;

namespace WPR_project.Repositories
{
    public class FrontOfficeMedewerkerRepository : IFrontOfficeMedewerkerRepository
    {
        private readonly GegevensContext _context;

        public FrontOfficeMedewerkerRepository(GegevensContext context)
        {
            _context = context;
        }
        public FrontofficeMedewerker GetFrontOfficeMedewerkerById(Guid id)
        {
            return _context.FrontofficeMedewerkers.Find(id);
        }

        public void Delete(Guid id)
        {
            var frontOfficeMedewerker = _context.FrontofficeMedewerkers.Find(id);
            if (frontOfficeMedewerker != null)
            {

                frontOfficeMedewerker.IsActive = false;

                var user = _context.Users.FirstOrDefault(u => u.Id == frontOfficeMedewerker.AspNetUserId);

                if (user != null)
                {

                    user.IsActive = false;
                }

                _context.SaveChanges();
            }
        }

        public void Update(FrontofficeMedewerker frontofficeMedewerker)
        {
            var emailUpdateIdentity = frontofficeMedewerker.medewerkerEmail;
            var user = _context.Users.FirstOrDefault(u => u.Id == frontofficeMedewerker.AspNetUserId);
            if (user != null)
            {
                user.Email = emailUpdateIdentity;
                user.UserName = emailUpdateIdentity;
                user.NormalizedEmail = emailUpdateIdentity.ToUpper();
                user.NormalizedUserName = emailUpdateIdentity.ToUpper();
                _context.Users.Update(user);
            }
            _context.FrontofficeMedewerkers.Update(frontofficeMedewerker);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<FrontofficeMedewerker> Getall()
        {
            return _context.FrontofficeMedewerkers.AsQueryable();
        }
    }
}
