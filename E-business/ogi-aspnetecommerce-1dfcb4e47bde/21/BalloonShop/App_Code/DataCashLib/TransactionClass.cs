using System.Xml.Serialization;

namespace DataCashLib
{
  public class TransactionClass
  {
    [XmlElement("TxnDetails")]
    public TxnDetailsClass TxnDetails = new TxnDetailsClass();
    private CardTxnRequestClass cardTxn;

    private HistoricTxnClass historicTxn;


    [XmlElement("CardTxn")]
    public CardTxnRequestClass CardTxn
    {
      get
      {
        if (historicTxn == null)
        {
          if (cardTxn == null)
          {
            cardTxn = new CardTxnRequestClass();
          }
          return cardTxn;
        }
        else
        {
          return null;
        }
      }
      set
      {
        cardTxn = value;
      }
    }

    [XmlElement("HistoricTxn")]
    public HistoricTxnClass HistoricTxn
    {
      get
      {
        if (cardTxn == null)
        {
          if (historicTxn == null)
          {
            historicTxn = new HistoricTxnClass();
          }
          return historicTxn;
        }
        else
        {
          return null;
        }
      }
      set
      {
        historicTxn = value;
      }
    }
  }
}