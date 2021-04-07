using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public Note(int id, string username, string content, int pinID, int fontID)
    {
        this.id = id;
        Username = username;
        Content = content;
        PinID = pinID;
        FontID = fontID;
    }

    public int id { get; set; }
    public string Username { get; set; }
    public string Content { get; set; }
    public int PinID { get; set; }
    public int FontID { get; set; }

}
