using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 货位Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ILocationService), ServiceLifetime = LifeTime.Transient)]
    public class LocationService : BaseService<Location>, ILocationService
    {
        /// <summary>
        /// 查询货位列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<LocationDto> GetList(LocationQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Id asc")
                .Where(predicate.ToExpression())
                .ToPage<Location, LocationDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Location GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加货位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Location AddLocation(Location model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改货位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateLocation(Location model)
        {
            return Update(model, true, "修改货位");
        }

        /// <summary>
        /// 清空货位
        /// </summary>
        /// <returns></returns>
        public bool TruncateLocation()
        {
            var newTableName = $"location_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("location", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入货位
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportLocation(List<Location> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "Id不能为空")
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
        /// 导出货位
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<LocationDto> ExportList(LocationQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new LocationDto()
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
        private static Expressionable<Location> QueryExp(LocationQueryDto parm)
        {
            var predicate = Expressionable.Create<Location>();

            predicate = predicate.AndIF(parm.LocationNumber != null, it => it.LocationNumber == parm.LocationNumber);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LocationName), it => it.LocationName == parm.LocationName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.State), it => it.State == parm.State);
            return predicate;
        }
    }
}