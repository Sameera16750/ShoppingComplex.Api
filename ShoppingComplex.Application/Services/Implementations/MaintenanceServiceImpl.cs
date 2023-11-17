using AutoMapper;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Application.Services.Implementations
{
    public class MaintenanceServiceImpl : IMaintenanceService
    {
        // Auto mapper instance
        private readonly IMapper _mapper;

        // maintenance repo instance
        private readonly IMaintenanceRepo _maintenanceRepo;

        // contractor repo instance
        private readonly IContractorRepo _contractorRepo;

        // constructor
        public MaintenanceServiceImpl(IMapper mapper, IMaintenanceRepo maintenanceRepo, IContractorRepo contractorRepo)
        {
            _mapper = mapper;
            _maintenanceRepo = maintenanceRepo;
            _contractorRepo = contractorRepo;
        }

        // for save Maintenance
        public HttpResponse SaveMaintenance(MaintenanceRequest maintenanceRequest)
        {
            try
            {
                Contractor? contractor = _contractorRepo.GetContractorById(maintenanceRequest.Contractor);
                if (contractor != null)
                {
                    if (_maintenanceRepo.SaveMaintenance(_mapper.Map<Maintenance>(maintenanceRequest)) > 0)
                    {
                        return new HttpResponse(200, "new Maintenance record adding succeeded");
                    }

                    return new HttpResponse(500, "internal server Error, Please try again later");
                }

                return new HttpResponse(404, "This Floor not found");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for update existing Maintenance
        public HttpResponse UpdateMaintenance(int id, MaintenanceRequest maintenanceRequest)
        {
            try
            {
                Contractor? contractor = _contractorRepo.GetContractorById(maintenanceRequest.Contractor);
                if (contractor != null)
                {
                    Maintenance maintenance = _mapper.Map<Maintenance>(maintenanceRequest);
                    maintenance.Id = id;
                    if (_maintenanceRepo.UpdateMaintenance(maintenance) > 0)
                    {
                        return new HttpResponse(200, "Maintenance Update Success");
                    }

                    return new HttpResponse(500, "internal server Error, Please try again later");
                }

                return new HttpResponse(404, "This Floor not found");
            }
            catch (Exception)
            {
                return new HttpResponse(500, "internal server Error, Please try again later");
            }
        }

        // for get Maintenance by id
        public HttpResponse GetMaintenanceById(int id)
        {
            try
            {
                Maintenance? maintenance = _maintenanceRepo.GetMaintenanceById(id);
                if (maintenance != null)
                {
                    return new HttpResponse(200, _mapper.Map<MaintenanceResponse>(maintenance));
                }

                return new HttpResponse(404, "Data not fond from this id");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get Maintenance list by status
        public HttpResponse GetMaintenanceListByStatus(int status)
        {
            try
            {
                List<Maintenance> maintenances = _maintenanceRepo.GetAllByStatus(status);
                if (maintenances.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<MaintenanceResponse>>(maintenances));
                }

                return new HttpResponse(200, "Data not fond from this status");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get all Maintenance list
        public HttpResponse GetAll()
        {
            try
            {
                List<Maintenance> maintenances = _maintenanceRepo.GetAll();
                if (maintenances.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<MaintenanceResponse>>(maintenances));
                }

                return new HttpResponse(200, "This Table is Empty");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for delete Maintenance
        public HttpResponse DeleteMaintenance(int id)
        {
            try
            {
                if (_maintenanceRepo.GetMaintenanceById(id) != null)
                {
                    if (_maintenanceRepo.DeleteMaintenance(id) > 0)
                    {
                        return new HttpResponse(200, "Maintenance Delete Succeeded");
                    }

                    return new HttpResponse(500, "Internal server Error");
                }

                return new HttpResponse(404, $"this element (maintenance id : {id}) not found in DB");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }
    }
}