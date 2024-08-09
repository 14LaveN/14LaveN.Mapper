using System.Reflection;

namespace Mapper;

/// <summary>
/// Represents the generic mapper class.
/// </summary>
/// <typeparam name="TSource">The generic source type.</typeparam>
/// <typeparam name="TDestination">The generic destination type</typeparam>
public sealed class GenericMapper<TSource, TDestination> 
    : IMapper<TSource, TDestination>
    where TDestination : new()
{
    ///<inheritdoc />
    public TDestination Map(TSource source)
    {
        TDestination destination = new TDestination();

        if (source is null)
            return destination;

        PropertyInfo[] sourceProperties =
            typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo[] destinationProperties = 
            typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo sourceProperty in sourceProperties)
        {
            PropertyInfo? destinationProperty = destinationProperties
                .FirstOrDefault(destProp =>
                    destProp.Name == sourceProperty.Name
                    && destProp.PropertyType == sourceProperty.PropertyType);

            if (destinationProperty is not null 
                && destinationProperty.CanWrite)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }

        return destination;
    }
}