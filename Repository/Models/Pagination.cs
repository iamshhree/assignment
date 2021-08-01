using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo.Models
{
    public class Pagination<T>
    {
        public string SearchedRecord { get; set; }
        public int NumberOfRecords { get; set; }
        public int PageNumber { get; set; }
        public int TotalRecordCount { get; set; }
        public List<T> ResponseResult { get; set; }

        public Pagination(int numberOfRecords,  int pageNumber)
        {
            NumberOfRecords = numberOfRecords;
            PageNumber = pageNumber;
        }

        public Pagination()
        {

        }
    }
}
