using Library.Domain.Entities;
using Library.Infrastructure.Repositories;
using Library.Domain.Configurations;
using System;
using Xunit;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class AbonentRepositoryTests
    {
        AbonentRepository abonentRepository = new AbonentRepository(ConnectionStrings.MSSQLConnectionString, "AbonentTable");

        [Fact]
        public async void TestAddAbonent()
        {
            Abonent abonent = new Abonent
            {
                Name = "Petya",
                Surname = "Pupkin",
                Patronymic = "Vasilievich",
                GenderId = 0,
                BirthDate = DateTime.Now
            };

            await abonentRepository.Create(abonent);
        }


        [Fact]
        public async void TestDeleteAbonent()
        {
            await abonentRepository.Delete(0);
        }

        [Fact]
        public async void TestReadAbonentById()
        {
            var abonent = abonentRepository.Read(0).Result;
        }

        [Fact]
        public async void TestReadAllAbonentsById()
        {
            var abonent = abonentRepository.ReadAll().Result;
        }

        [Fact]
        public async void TestUpdateAbonent()
        {
            //NOT WORKING
            //NOT WORKING
            //NOT WORKING
            var abonent = new Abonent
            {
                Name = "Petya",
                Surname = "Pupkin",
                Patronymic = "Vasilevich",
                GenderId = 0,
                BirthDate = DateTime.Now
            };

            abonentRepository.Update(4005, abonent);
        }
    }
}
