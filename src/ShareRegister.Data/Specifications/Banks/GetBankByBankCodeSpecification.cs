using ShareRegister.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShareRegister.Data.Specifications.Banks;
public class GetBankByBankCodeSpecification : Specification<Bank>
{
    public GetBankByBankCodeSpecification(string bankCode) : base(bank=>bank.BankCode==bankCode)
    {
    }
}
