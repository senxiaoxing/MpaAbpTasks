using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpMVC5.Dto
{
    /// <summary>
    /// 支持分页、排序和过滤的InputDto
    /// </summary>
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
        //接收DataTables的参数
        public int Draw { get; set; }
        public int Length
        {
            get
            {
                return this.MaxResultCount;
            }

            set
            {
                this.MaxResultCount = value;
            }
        }
        public int Start
        {
            get
            {
                return this.SkipCount;
            }

            set
            {
                this.SkipCount = value;
            }
        }
    }
}
