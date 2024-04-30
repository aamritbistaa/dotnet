
public class BreakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = new Dictionary<Guid, Breakfast>();
    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast GetBreakfast(Guid id)
    {
        //check if id is present as key or not

        if (_breakfasts.ContainsKey(id))
        {
            return _breakfasts[id];
        }
        throw new Exception("id does not exist");
    }
    public List<Breakfast> GetAllBreakfast()
    {
        if (_breakfasts.Count == 0)
        {
            throw new Exception("no data");
        }
        return _breakfasts.Values.ToList();
    }

    public void UpdateBreakfast(Breakfast breakfast)
    {

        _breakfasts[breakfast.Id] = breakfast;

    }
    public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }


}