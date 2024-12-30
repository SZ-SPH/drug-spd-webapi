using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 生产厂家Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IManufacturerService), ServiceLifetime = LifeTime.Transient)]
    public class ManufacturerService : BaseService<Manufacturer>, IManufacturerService
    {
        /// <summary>
        /// 查询生产厂家列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ManufacturerDto> GetList(ManufacturerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Manufacturer, ManufacturerDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Manufacturer GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加生产厂家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Manufacturer AddManufacturer(Manufacturer model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改生产厂家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateManufacturer(Manufacturer model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空生产厂家
        /// </summary>
        /// <returns></returns>
        public bool TruncateManufacturer()
        {
            var newTableName = $"Manufacturer_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("Manufacturer", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入生产厂家
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportManufacturer(List<Manufacturer> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 导出生产厂家
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ManufacturerDto> ExportList(ManufacturerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new ManufacturerDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Manufacturer> QueryExp(ManufacturerQueryDto parm)
        {
            var predicate = Expressionable.Create<Manufacturer>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Code), it => it.Code == parm.Code);
            return predicate;
        }

        public Manufacturer GetnNameInfo(string name)
        {
            var response = Queryable()
                .Where(x => x.Name == name)
                .First();

            return response;
        }
    }
}