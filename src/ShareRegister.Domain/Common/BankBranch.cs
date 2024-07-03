using FluentResults;
using System.Diagnostics;

namespace ShareRegister.Domain.Common;
public class BankBranch : AuditableEntity
{
    public string BranchName { get;private set; }
    public string BranchCode { get;private set; }

    private BankBranch(string branchName,string branchCode)
    {
        this.BranchName = branchName;
        this.BranchCode = branchCode;
    }

    public static Result<BankBranch> Create(string branchName, string branchCode)
    {
        Result validationResult = ValidateBranchInformation(branchName, branchCode);
        if (validationResult.IsSuccess)
        {
            return new BankBranch(branchName, branchCode);
        }
        return validationResult;
    }

    private static Result ValidateBranchInformation(string branchName, string branchCode)
    {
        return Result.Merge(
        Result.FailIf(String.IsNullOrWhiteSpace(branchName), "Branch name is required."),
        Result.FailIf(String.IsNullOrWhiteSpace(branchCode), "Branch code is required.")
        );
    }
}
