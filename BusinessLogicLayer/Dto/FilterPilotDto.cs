namespace BusinessLogicLayer.Dto
{
    public class FilterPilotDto
    {
        public string? Team {get; set;}

        public string? Nationality {get; set;}
        public Boolean? isChampion {get; set;}     
                //Pagination
        public int Page {get; set;}
        public int PageSize {get; set;}
       

    }
    
}
