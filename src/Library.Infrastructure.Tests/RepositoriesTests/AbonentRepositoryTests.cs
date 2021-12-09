using Library.Domain.Entities;
using Library.Infrastructure.Repositories;
using System;
using Xunit;
using System.Configuration;
using Library.Domain.Configurations;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class AbonentRepositoryTests
    {
        AbonentRepository abonentRepository = new AbonentRepository(ConnectionStrings.MSSQLConnectionString);

        [Fact]
        public async void TestAddAbonent()
        {
            Abonent abonent = new Abonent
            {
                Id = 0,
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
            await abonentRepository.Delete(1);
        }
    }
}
