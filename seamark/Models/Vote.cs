using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;

namespace seamark.Models
{
  public class Vote
  {
    
    [DisplayName("賛成の数")]
    public int Agree { get; set; }

    [DisplayName("反対の数")]
    public int Disagree { get; set; }

    [DisplayName("総投票数")]
    public int TotalVotes { get; set; }

    [DisplayName("ID")]
    public int Id { get; set; }

    [DisplayName("投票作成者")]
    public String Name { get; set; }

    [DisplayName("内容")]
    public String Text { get; set; }

    [DisplayName("締め切り日時")]
    [DisplayFormat(DataFormatString="{0:yyyy年MM月dd日hh時mm分}")]
    public DateTime Deadline { get; set; }

    [DisplayName("投稿日時")]
    [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日hh時mm分}")]
    public DateTime Posted { get; set; }

    [DisplayName("記事")]
    public virtual ICollection<article> Articles { get; set; }

    [DisplayName("アカウント")]
    public virtual ICollection<Account> Accounts { get; set; } 

    
  }
}