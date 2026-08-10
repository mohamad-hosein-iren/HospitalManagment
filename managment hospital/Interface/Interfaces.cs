namespace managment_hospital.Interface
{
    public interface IIdentifiable
    {
        string GetId();
        bool ValidateId();
    }
    public interface IPrintable
    {
        string GetPrintableFormat();
    }
}
