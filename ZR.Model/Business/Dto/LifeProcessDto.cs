
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 查询对象
    /// </summary>
    public class LifeProcessQueryDto : PagerInfo 
    {
        public string Receiptid { get; set; }
        public string DRUGId { get; set; }
        public string CodeId { get; set; }
        public int? MedicalAdviceId { get; set; }

    }

    /// <summary>
    /// 输入输出对象
    /// </summary>
    public class LifeProcessDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        public int Id { get; set; }

        public string Receiptid { get; set; }

        public string DRUGId { get; set; }

        public string CodeId { get; set; }

        public int? Operator { get; set; }

        public int? Times { get; set; }

        public string Details { get; set; }
        public int? MedicalAdviceId { get; set; }

        

    }
}