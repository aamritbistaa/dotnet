
public interface IBreakfastService
{

    void CreateBreakfast(Breakfast breakfastRequest);

    Breakfast GetBreakfast(Guid id);

    void DeleteBreakfast(Guid id);

    void UpdateBreakfast(Breakfast breakfast);

    List<Breakfast> GetAllBreakfast();
}