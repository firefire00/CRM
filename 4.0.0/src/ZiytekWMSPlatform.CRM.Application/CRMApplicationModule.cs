using System;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nezada.Common.Model;
using Nezada.Common.Utils;
using ZiytekWMSPlatform.CRM.AppServices;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(
        typeof(CRMCoreModule),
        typeof(AbpAutoMapperModule))]
    public class CRMApplicationModule : AbpModule
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CRMApplicationModule).GetAssembly());
        }

        /// <summary>
        /// 
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                #region 客户关系映射
                mapper.CreateMap<Ppt_Customer_AppCreateInputDto, Ppt_Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => CodeUtils.IdGenerator()))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime == null ? DateTime.Now : src.CreationTime))
                .ForMember(dest => dest.LastModificationTime, opt => opt.MapFrom(src => src.LastModificationTime == null ? DateTime.Now : src.LastModificationTime))
                .ForMember(dest => dest.CreatorUserId, opt => opt.MapFrom(src => src.OperaterUserId))
                .ForMember(dest => dest.LastModifierUserId, opt => opt.MapFrom(src => src.OperaterUserId));
                mapper.CreateMap<Ppt_Customer_OutputDto, Ppt_Customer_AppOutputDto>();
                mapper.CreateMap<Ppt_Customer, Ppt_Customer_OutputDto>();
                mapper.CreateMap<Ppt_Customer, Ppt_Customer_AppOutputDto>();
                mapper.CreateMap<Ppt_Customer_OutputDto, SelectedItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Isactive));
                #endregion

                #region 客户-仓库关系映射
                mapper.CreateMap<Desc_Customer_Warehouse_AppCreateInputDto, Desc_Customer_Warehouse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => CodeUtils.IdGenerator()))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime == null ? DateTime.Now : src.CreationTime))
                .ForMember(dest => dest.LastModificationTime, opt => opt.MapFrom(src => src.LastModificationTime == null ? DateTime.Now : src.LastModificationTime))
                .ForMember(dest => dest.CreatorUserId, opt => opt.MapFrom(src => src.OperaterUserId))
                .ForMember(dest => dest.LastModifierUserId, opt => opt.MapFrom(src => src.OperaterUserId));
                mapper.CreateMap<Desc_Customer_Warehouse_OutputDto, Desc_Customer_Warehouse_AppOutputDto>();
                mapper.CreateMap<Desc_Customer_Warehouse, Desc_Customer_Warehouse_OutputDto>();
                mapper.CreateMap<Desc_Customer_Warehouse, Desc_Customer_Warehouse_AppOutputDto>();
                #endregion

                #region 客户-收货人关系映射
                mapper.CreateMap<Desc_Customer_Consignee_AppCreateInputDto, Desc_Customer_Consignee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => CodeUtils.IdGenerator()))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime == null ? DateTime.Now : src.CreationTime))
                .ForMember(dest => dest.LastModificationTime, opt => opt.MapFrom(src => src.LastModificationTime == null ? DateTime.Now : src.LastModificationTime))
                .ForMember(dest => dest.CreatorUserId, opt => opt.MapFrom(src => src.OperaterUserId))
                .ForMember(dest => dest.LastModifierUserId, opt => opt.MapFrom(src => src.OperaterUserId));
                mapper.CreateMap<Desc_Customer_Consignee_OutputDto, Desc_Customer_Consignee_AppOutputDto>();
                mapper.CreateMap<Desc_Customer_Consignee, Desc_Customer_Consignee_OutputDto>();
                mapper.CreateMap<Desc_Customer_Consignee, Desc_Customer_Consignee_AppOutputDto>();
                #endregion

                #region 客户-物资关系映射
                mapper.CreateMap<Desc_Customer_Material_AppCreateInputDto, Desc_Customer_Material>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => CodeUtils.IdGenerator()))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime == null ? DateTime.Now : src.CreationTime))
                .ForMember(dest => dest.LastModificationTime, opt => opt.MapFrom(src => src.LastModificationTime == null ? DateTime.Now : src.LastModificationTime))
                .ForMember(dest => dest.CreatorUserId, opt => opt.MapFrom(src => src.OperaterUserId))
                .ForMember(dest => dest.LastModifierUserId, opt => opt.MapFrom(src => src.OperaterUserId));
                mapper.CreateMap<Desc_Customer_Material_OutputDto, Desc_Customer_Material_AppOutputDto>();
                mapper.CreateMap<Desc_Customer_Material, Desc_Customer_Material_OutputDto>();
                mapper.CreateMap<Desc_Customer_Material, Desc_Customer_Material_AppOutputDto>();
                mapper.CreateMap<SaveExcel_AppInputDto, Desc_Customer_Material>();
                mapper.CreateMap<Desc_Customer_Material_OutputDto, SelectedItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Materialid));
                #endregion

                #region 收货人关系映射
                mapper.CreateMap<Ppt_Consignee_AppCreateInputDto, Ppt_Consignee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => CodeUtils.IdGenerator()))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime == null ? DateTime.Now : src.CreationTime))
                .ForMember(dest => dest.LastModificationTime, opt => opt.MapFrom(src => src.LastModificationTime == null ? DateTime.Now : src.LastModificationTime))
                .ForMember(dest => dest.CreatorUserId, opt => opt.MapFrom(src => src.OperaterUserId))
                .ForMember(dest => dest.LastModifierUserId, opt => opt.MapFrom(src => src.OperaterUserId));
                mapper.CreateMap<Ppt_Consignee_OutputDto, Ppt_Consignee_AppOutputDto>();
                mapper.CreateMap<Ppt_Consignee, Ppt_Consignee_OutputDto>();
                mapper.CreateMap<Ppt_Consignee, Ppt_Consignee_AppOutputDto>();
                mapper.CreateMap<Ppt_Consignee_OutputDto, SelectedItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Consigneename))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Consigneename));
                #endregion
            });
        }
    }
}