using ApiUserBank.Context;
using ApiUserBank.DTO;
using ApiUserBank.DTO.Mappings;
using ApiUserBank.Repositories;
using ApiUserBank.Services;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using TestUserBank.Seeders;
using NSubstitute;
using ApiUserBank.Models;

namespace TestUserBank
{
    public class UnitTest1
    {
        private readonly IUserBanksService _userBankService;
        private readonly IUserBankRepository _userBankRepository;
        private readonly IMapper _mapper;
        private readonly Seederss _seeders;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString =
           "Server=containers-us-west-143.railway.app;DataBase=railway;uid=root;Pwd=xM2vPd8GBjFXH9vDIWnB;Port=5857";
        static UnitTest1()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;
        }
        public UnitTest1()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }
            );
            _mapper = config.CreateMapper();
            var context = new AppDbContext(dbContextOptions);

            //UnitTestMockInicializer db = new DbUnitTestMockInicializer();
            //.Seed(context);U
            _userBankService = Substitute.For<IUserBanksService>();
            _userBankRepository = Substitute.For<IUserBankRepository>();
           // _userBankRepository = new UserBankRepository(context);
            _seeders = new();
        }
        [Fact]
        public void GetAllUsersWithSuccess()
        {
            //Arrange
           
            var service = new UserBankService(_userBankRepository, _mapper);

            //Act
            var data = service.GetAll();

            //Assert
            data.Should().NotBeNull();
        }
        [Fact]
        public void TestGetUserByAccountComSucesso()
        {
            //arrange
            var user = _seeders.FakeOne();

            _userBankRepository.GetUserByAccount(Arg.Any<int>()).Returns(user);
            var userResponse = _mapper.Map<UserBankDTO>(user);
            //act
            var data= _userBankService.GetUserByAccount(userResponse.Id);

            //assert
            data.Should().NotBeEquivalentTo(userResponse); 

        }

      
    }
}