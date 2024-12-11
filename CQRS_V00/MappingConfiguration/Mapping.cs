using CQRS_V00.Contract;

using Mapster;

namespace CQRS_V00.MappingConfiguration;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<EmployeeRequest, Employee>()
        //    .Map(dest => dest.Birthday, src => DateOnly.FromDateTime(src.BirthDay));

    }
}
