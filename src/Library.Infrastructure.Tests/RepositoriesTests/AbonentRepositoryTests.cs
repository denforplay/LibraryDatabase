using Library.Domain.Entities;
using Library.Infrastructure.Repositories;
using Library.Domain.Configurations;
using System;
using Xunit;
using System.Linq;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class AbonentRepositoryTests
    {
        private AbonentRepository _abonentRepository = new AbonentRepository(ConnectionStrings.MSSQLConnectionString);
        
        [Fact]
        public async void TestAddAbonent()
        {
            var abonentsBeforeCreating = await _abonentRepository.ReadAll();

            Abonent abonent = new Abonent
            {
                Name = "Petya",
                Surname = "Pupkin",
                Patronymic = "Vasilievich",
                GenderId = 0,
                BirthDate = DateTime.Now
            };

            await _abonentRepository.Create(abonent);
            var abonentsAfterCreating = await _abonentRepository.ReadAll();
            Assert.Equal(abonentsBeforeCreating.Count(), abonentsAfterCreating.Count() - 1);
            await _abonentRepository.Delete(abonent.Id);
        }


        [Fact]
        public async void TestDeleteAbonent()
        {
            var abonentsBeforeDeleting = await _abonentRepository.ReadAll();
            var deletedAbonent = abonentsBeforeDeleting.Last();
            await _abonentRepository.Delete(deletedAbonent.Id);
            var abonentsAfterDeleting = await _abonentRepository.ReadAll();
            Assert.Equal(abonentsBeforeDeleting.Count(), abonentsAfterDeleting.Count() + 1);
            await _abonentRepository.Create(deletedAbonent);
        }

        [Fact]
        public async void TestReadAbonentById()
        {
            var abonents = await _abonentRepository.ReadAll();
            var abonentById = await _abonentRepository.Read(abonents.Last().Id);
            Assert.NotNull(abonentById);
        }

        [Fact]
        public async void TestReadAllAbonentsById()
        {
            var abonent = _abonentRepository.ReadAll().Result;
            Assert.NotNull(abonent);
        }

        [Fact]
        public async void TestUpdateAbonent()
        {
            Abonent abonentBeforeUpdating = _abonentRepository.ReadAll().Result.Last();

            var abonent = new Abonent
            {
                Name = "Petya",
                Surname = "Pupkin",
                Patronymic = "Vasilevich",
                GenderId = 0,
                BirthDate = DateTime.Now
            };

            await _abonentRepository.Update(abonentBeforeUpdating.Id, abonent);
            Abonent abonentAfterUpdating = (await _abonentRepository.ReadAll()).Last();
            Assert.NotEqual(abonentBeforeUpdating.BirthDate, abonentAfterUpdating.BirthDate);
            await _abonentRepository.Update(abonentAfterUpdating.Id, abonentBeforeUpdating);
        }
    }
}
