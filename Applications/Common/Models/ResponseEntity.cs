namespace Applications.Common.Models;

public  class ResponseEntity<T>
{
    public ResponseEntity(T _data)
    {
        data = _data;
    }

    public ResponseEntity()
    {
        
    }
    public  string message { get; set; }
    
    public  int code { get; set; }
    
    public  T data { get; set; }

    public IEnumerable<string> options { get; set; } = new List<string>();


}



