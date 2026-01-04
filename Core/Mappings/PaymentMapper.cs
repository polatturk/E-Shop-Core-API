using Core.DTOs;
using Core.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class PaymentMapper
    {
        public static partial Payment ToEntity(PaymentCreateDto dto);

        public static partial Payment ToEntity(PaymentStatusUpdateDto dto);

        public static partial PaymentResponseDto ToResponseDto(Payment payment);
    }
}
