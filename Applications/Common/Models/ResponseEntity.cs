namespace Applications.Common.Models;

public  class ResponseEntity<T>
{
    public ResponseEntity(T _data,string _message ="",int _code = 200)
    {
        data = _data;
        message = _message;
        code = _code;
    }

    public ResponseEntity()
    {
        
    }
    public  string message { get; set; }
    
    public  int code { get; set; }
    
    public  T data { get; set; }

    public IEnumerable<string> options { get; set; } = new List<string>();

    public static ResponseEntity<T> Success(string message, T data,int code )
    {
        return new ResponseEntity<T>(data,message,code);
    }

    public static ResponseEntity<T> Error(string message, T data, int code = 400)
    {
        return new ResponseEntity<T>(data,message,code);
    }


}



