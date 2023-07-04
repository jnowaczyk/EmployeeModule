using EmployeeModule.Domain;

namespace EmployeeModule.BusinessLogic;

public interface IPromotionDispatcher
{
    void Dispatch(Employee employee);
}


public class EmployeePromotionHandler
{
    private IPromotionDispatcher _promotionDispatcher;

    public EmployeePromotionHandler(IPromotionDispatcher promotionDispatcher)
    {
        _promotionDispatcher = promotionDispatcher;
    }

    public void Promote(Employee employee)
    {
        if (employee != null)
        {
            if (employee.IsActive)
            {
                if (employee.TerminationDate.HasValue)
                {
                    throw new Exception("Cannot promote the employee with termination date");
                }

                if (employee.EvaluationPoints < 115)
                    return;

                if (employee.Role.ToLower() == "manager")
                {
                    throw new Exception("Cannot promote the employee with manager role");
                }
                
                if ((DateTime.Now - employee.HireDate).TotalDays > 180)
                {
                    if (employee.IsActive)
                    {
                        _promotionDispatcher.Dispatch(employee);
                    }
                }
            }
        }
    }
}