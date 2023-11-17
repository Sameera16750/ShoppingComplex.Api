using AutoMapper;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Application.Services.Implementations
{
    public class ContractorServiceImpl : IContractorService
    {
        // Auto mapper Instance
        private readonly IMapper _mapper;

        // Contractor repo instance
        private readonly IContractorRepo _contractorRepo;

        // constructor
        public ContractorServiceImpl(IMapper mapper, IContractorRepo contractorRepo)
        {
            _mapper = mapper;
            _contractorRepo = contractorRepo;
        }

        // for save Contractor
        public HttpResponse SaveContractor(ContractorRequest contractorRequest)
        {
            try
            {
                if (_contractorRepo.SaveContractor(_mapper.Map<Contractor>(contractorRequest)) > 0)
                {
                    return new HttpResponse(200, "data adding succeeded");
                }

                return new HttpResponse(500, "internal server Error, Please try again later");
            }
            catch (Exception)
            {
                return new HttpResponse(500, "internal server Error");
            }
        }

        // for update existing Contractor
        public HttpResponse UpdateContractor(int id, ContractorRequest contractorRequest)
        {
            try
            {
                Contractor contractor = _mapper.Map<Contractor>(contractorRequest);
                contractor.Id = id;
                if (_contractorRepo.UpdateContractor(contractor) > 0)
                {
                    return new HttpResponse(200, "Contractor Update Success");
                }
                else
                {
                    return new HttpResponse(500, "internal server Error, Please try again later");
                }
            }
            catch (Exception)
            {
                return new HttpResponse(500, "internal server Error, Please try again later");
            }
        }

        // for get Contractor by id
        public HttpResponse GetContractorById(int id)
        {
            try
            {
                Contractor? contractor = _contractorRepo.GetContractorById(id);
                if (contractor != null)
                {
                    return new HttpResponse(200, _mapper.Map<ContractorResponse>(contractor));
                }

                return new HttpResponse(200, "Data not fond from this id");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get Contractor list by status
        public HttpResponse GetContractorListByStatus(int status)
        {
            try
            {
                List<Contractor> contractors = _contractorRepo.GetAllByStatus(status);
                if (contractors.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<ContractorResponse>>(contractors));
                }

                return new HttpResponse(200, "Data not fond from this status");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get all Contractor list
        public HttpResponse GetAll()
        {
            try
            {
                List<Contractor> contractors = _contractorRepo.GetAll();
                if (contractors.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<ContractorResponse>>(contractors));
                }

                return new HttpResponse(404, "This Table is Empty");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for delete Contractor
        public HttpResponse DeleteContractor(int id)
        {
            try
            {
                if (_contractorRepo.GetContractorById(id) != null)
                {
                    if (_contractorRepo.Delete(id) > 0)
                    {
                        return new HttpResponse(200, "Contractor Delete Succeeded");
                    }

                    return new HttpResponse(500, "Internal server Error");
                }

                return new HttpResponse(404, $"this element (Contractor id : {id}) not found in DB");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }
    }
}