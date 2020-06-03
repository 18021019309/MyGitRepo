using AutoMapper;
using FirstPakWebApi.Data.Models;
using FirstPakWebApi.ViewModel;
using LinqPagination;

namespace FirstPakWebApi.Transform
{
    public class ToViewModelProfile : Profile
    {
        public ToViewModelProfile()
        {
            //CreateMap<CaseInfo, ActionResult>()
            //    .ForMember(dest => dest.NameText, opt => opt.MapFrom(src => src.Name + src.Id));
            
            CreateMap<ViewUser, User>();

            CreateMap<Menu, ViewMenu>();

            CreateMap<EmployeeInfo, ViewEmployeeInfo>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                //.ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.User.Account))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.User.Password));

            CreateMap<ViewEmployeeInfo, EmployeeInfo>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));


            CreateMap<Position, ViewPosition>();

            CreateMap<ViewPosition, Position>();

            CreateMap<Department, ViewDepartment>();

            CreateMap<ViewDepartment, Department>();

            CreateMap<Role, ViewRole>();
            CreateMap<ViewRole, Role>();

            CreateMap<EducationLevel, ViewDropDownList>()
              .ForMember(dest => dest.Code, opt => opt.MapFrom(scr => scr.Id))
              .ForMember(dest => dest.CodeName, opt => opt.MapFrom(scr => scr.EducationName));

            CreateMap<EmployeeInfo, ViewDropDownList>()
              .ForMember(dest => dest.Code, opt => opt.MapFrom(scr => scr.Id))
              .ForMember(dest => dest.CodeName, opt => opt.MapFrom(scr => scr.UserName));

            CreateMap<Department, ViewDropDownList>()
             .ForMember(dest => dest.Code, opt => opt.MapFrom(scr => scr.Id))
             .ForMember(dest => dest.CodeName, opt => opt.MapFrom(scr => scr.DepartmentName));

            CreateMap<Position, ViewDropDownList>()
             .ForMember(dest => dest.Code, opt => opt.MapFrom(scr => scr.Id))
             .ForMember(dest => dest.CodeName, opt => opt.MapFrom(scr => scr.PositionName));

            CreateMap<Role, ViewDropDownList>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(scr => scr.Id))
            .ForMember(dest => dest.CodeName, opt => opt.MapFrom(scr => scr.RoleName));

            CreateMap<User,ViewDropDownList>()
                .ForMember(dest=>dest.Code,opt=>opt.MapFrom(scr=>scr.Id))
                .ForMember(dest => dest.CodeName, opt => opt.MapFrom(scr => scr.Account));

            CreateMap(typeof(PageResult<>), typeof(ViewPageResult<>))
              .ForMember("TotalCount", o => o.MapFrom("SourceCount"))
              .ForMember("DataSource", o => o.MapFrom("Results"));
        }
    }
}
