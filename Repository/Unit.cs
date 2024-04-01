﻿using TravelWeb.Data;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Repository
{
    public class Unit : IUnit
    {
        private ApplicationDbContext _context;
        public Unit(ApplicationDbContext context) 
        { 
            _context = context;
            Category = new CategoryRepository(_context);
            Destination = new DestinationRepository(_context);
        }
        public ICategoryRepository Category {get; private set;}

        public IDestinationRepository Destination { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
