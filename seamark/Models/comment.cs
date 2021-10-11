using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace seamark.Models
{
  public class Comment
  {
    [DisplayName("名前")]
    public String Name { get; set; }

    [DisplayName("ID")]
    public int Id { get; set; }

    [DisplayName("記事")]
    public String Text { get; set; }
    [DisplayName("削除フラグ")]
    public Boolean Deleteflag { get; set; }

    [DisplayName("記事")]
    public virtual article Article { get; set; }
  }
}