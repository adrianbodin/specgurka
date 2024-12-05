namespace ReqnrollDemo.Spec.StepDefinitions;

[Binding]
public class ManageEmployeesStepDefinitions
{
    private Department? _department;

    [BeforeScenario]
    public void BeforeScenario()
    {
        _department = null;
    }

    [Given(@"att jag är inloggad som HR-chef")]
    public void GivenAttJagArInloggadSomHrChef()
    {
        Console.WriteLine("Logged in as HR manager!");
    }

    [Given(@"I am on the ""(.*)"" page")]
    public void GivenIAmOnThePage(string page)
    {
        Console.WriteLine($"I am on the page {page}");
    }

    [Given(@"att jag är på sidan ""(.*)""")]
    public void GivenAttJagArPaSidan(string page)
    {
        Console.WriteLine($"Navigated to {page} page!");
    }

    [Given(@"att avdelningen ""(.*)"" finns med följande anställda:")]
    public void GivenAttAvdelningenFinnsMedFoljandeAnstallda(string departmentName, Table table)
    {
        _department = new Department(departmentName);

        foreach (var row in table.Rows)
        {
            var employee = new Employee(row["Namn"], Enum.Parse<Role>(row["Roll"]));
            _department.AddEmployee(employee);
        }
    }

    [When(@"jag lägger till en anställd ""(.*)"" med rollen ""(.*)"" till avdelningen ""(.*)""")]
    public void WhenJagLaggerTillEnAnstalldMedRollenTillAvdelningen(string employeeName, string employeeRole, string departmentName)
    {
        var employee = new Employee(employeeName, Enum.Parse<Role>(employeeRole));
        _department?.AddEmployee(employee);
    }

    [Then(@"ska ""(.*)"" läggas till i listan över anställda i avdelningen ""(.*)""")]
    public void ThenSkaLaggasTillIListanOverAnstalldaIAvdelningen(string employeeName, string departmentName)
    {
        var employee = _department?.Employees.FirstOrDefault(e => e.Name == employeeName);

        Assert.NotNull(employee);
    }

    [Given(@"att en anställd ""(.*)"" finns i avdelningen ""(.*)""")]
    public void GivenAttEnAnstalldFinnsIAvdelningen(string employeeName, string departmentName)
    {
        _department = new Department(departmentName);
        var employee = new Employee(employeeName, Role.Engineer);
        _department.AddEmployee(employee);
    }

    [When(@"jag tar bort ""(.*)"" från avdelningen ""(.*)""")]
    public void WhenJagTarBortFranAvdelningen(string employeeName, string departmentName)
    {
        var employee = _department?.Employees.FirstOrDefault(e => e.Name == employeeName);
        _department?.RemoveEmployee(employee.Id);
    }

    [Then(@"ska ""(.*)"" inte längre visas i listan över anställda i avdelningen ""(.*)""")]
    public void ThenSkaInteLangreVisasIListanOverAnstalldaIAvdelningen(string employeeName, string departmentName)
    {
        var employee = _department?.Employees.FirstOrDefault(e => e.Name == employeeName);

        employee.Should().BeNull();
    }
}