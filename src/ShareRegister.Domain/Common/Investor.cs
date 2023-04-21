using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareRegister.Domain.Common;
public abstract class  Investor : AuditableEntity
{
    public string IdentificationNumber { get; set; }
    public IdentificationType IdentificationType { get; set; }
    public ICollection<BankAccount> BankAccounts { get; set; }
}
