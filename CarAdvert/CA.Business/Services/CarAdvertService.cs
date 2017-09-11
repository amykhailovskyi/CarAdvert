using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CA.Business.DTOs;
using CA.Data.Entities;
using CA.Data.Repositories;
using FluentValidation;

namespace CA.Business.Services
{
    public class CarAdvertService
    {
        private readonly Repository<CarAdvert> _carAdvertRepository;
        private readonly CarAdvertDtoValidator _validator;

        public CarAdvertService(Repository<CarAdvert> carAdvertRepository)
        {
            _carAdvertRepository = carAdvertRepository;
            _validator = new CarAdvertDtoValidator();
        }

        public async Task<List<CarAdvertDto>> GetAll(string sortBy = null)
        {
            IEnumerable<CarAdvert> items = await _carAdvertRepository.GetAllAsync();
            var dtoItems = items.Select(Mapper.Map<CarAdvert, CarAdvertDto>).ToList();

            return dtoItems.OrderBy(GetOrderProperty(sortBy)).ToList();
        }

        public async Task<CarAdvertDto> GetById(int id)
        {
            return Mapper.Map<CarAdvert, CarAdvertDto>(await _carAdvertRepository.GetAsync(id));
        }

        public async Task<int> Add(CarAdvertDto obj)
        {
            await _validator.ValidateAndThrowAsync(obj);

            CarAdvert entity = Mapper.Map<CarAdvertDto, CarAdvert>(obj);
            return await _carAdvertRepository.InsertAsync(entity);
        }

        public async Task Update(CarAdvertDto obj)
        {
            await _validator.ValidateAndThrowAsync(obj);

            CarAdvert entity = Mapper.Map<CarAdvertDto, CarAdvert>(obj);
            await _carAdvertRepository.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            CarAdvert entity = await _carAdvertRepository.GetAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"There is no advert with id {id}");
            }

            await _carAdvertRepository.DeleteAsync(entity);
        }

        // todo: find more elegant way to define sorting property. Consider using Expression
        private Func<CarAdvertDto, object> GetOrderProperty(string sortBy)
        {
            switch ((sortBy ?? "id").ToLower())
            {
                case "title":
                    return r => r.Title;
                case "price":
                    return  r => r.Price;
                case "mileage":
                    return r => r.Mileage;
                case "firstRegistration":
                    return r => r.FirstRegistration;
                default:
                    return r => r.Id;
            }
        }
    }
}
