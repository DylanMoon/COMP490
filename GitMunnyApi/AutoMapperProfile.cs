using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GitMunnyApi.Dtos.Transactions;

namespace GitMunnyApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
                CreateMap<TransactionDto, TransactionModel>();
                CreateMap<TransactionModel, TransactionDto>();
        }
    }
}