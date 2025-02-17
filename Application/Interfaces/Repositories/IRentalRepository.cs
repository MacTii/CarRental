﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRentalRepository
    {
        public IEnumerable<Rental> GetAll();
        public Rental? GetByID(int rentalID);
        public IEnumerable<Rental> GetByUsername(string username);
        public void Insert(Rental rental);
        public void Update(int rentalID, Rental rental);
        public void Delete(int rentalID);
        public void Save();
    }
}
