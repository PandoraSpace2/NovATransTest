namespace UI
{
    public class ReductorModel
    {
        public int SelectedId { get; set; }
        public ReductorState State { get; set; }

        public ReductorModel()
        {
            SelectedId = -1;
            State = ReductorState.Estrangement;
        }
    }

    public enum ReductorState
    {
        Approach, Estrangement
    }
}