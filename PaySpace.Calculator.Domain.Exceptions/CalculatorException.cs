namespace PaySpace.Calculator.Domain.Exceptions
{
    public sealed class InvalidPostalCodeException() : InvalidOperationException("Invalid Postal code. Calculator not found");
    public sealed class EmptyPostalCodeException() : InvalidOperationException("Empty Postal code.Calculator not found");
    public sealed class NoCalcSettingsException() : InvalidOperationException("No calc settingd.Calculator not found");
    public sealed class EmptyCalcTypeException() : InvalidOperationException("Empty calc type.Calculator not found");


}