using MyDHLAPI_Test_App.com.dhl.wsbexpress.epod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyDHLAPI_Test_App.SOAP
{
    public partial class ePOD : Form
    {
        private string GloWS_Request;
        private string GloWS_Response;

        public ePOD()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Enabled = false;
            //    this.UseWaitCursor = true;
            //    Cursor.Current = Cursors.WaitCursor;

            //    if (string.IsNullOrWhiteSpace(txtAccountNumber.Text)
            //        || string.IsNullOrWhiteSpace(txtAWBNumber.Text))
            //    {
            //        MessageBox.Show("Missing data.");
            //        return;
            //    }
            //    if ((string) cmbPODType.SelectedItem == "")
            //    {
            //        cmbPODType.SelectedIndex = 1;
            //    }

            //    txtAccountNumber.Text = txtAccountNumber.Text.Trim();
            //    txtAWBNumber.Text = txtAWBNumber.Text.Trim();

            //    shipmentDocumentRetrieveReqMSG req = new shipmentDocumentRetrieveReqMSG();
            //    HDR hdr = new HDR
            //    {
            //        Dtm = DateTime.Now,
            //        Id = "TareTesting", // Guid.NewGuid().ToString("N"),
            //        Sndr = new PartIdentification()
            //        {
            //            AppCd = "DCG"
            //            , AppNm = "DCG"
            //            , CmptNm = "HP"
            //        },
            //        Ver = "1.038"
            //    };

            //    req.Hdr = hdr;

            //    shipmentDocumentRetrieveReqMSGBD bd = new shipmentDocumentRetrieveReqMSGBD();
            //    List<CdmGenericRequest_GenericRequestCriteria> genrc_rq = new List<CdmGenericRequest_GenericRequestCriteria>();

            //    switch ((string) cmbPODType.SelectedItem)
            //    {
            //        case "Detailed":
            //            genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "IMG_CONTENT", Val = "epod-detail-esig" });
            //            break;
            //        case "Table Summary":
            //            genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "IMG_CONTENT", Val = "epod-table-detail" });
            //            break;
            //        case "Table Detailed":
            //            genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "IMG_CONTENT", Val = "epod-table-summary" });
            //            break;
            //        case "Summary":
            //        default:
            //            genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "IMG_CONTENT", Val = "epod-summary-esig" });
            //            break;
            //    }
                
            //    genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "IMG_FORMAT", Val = "PDF" });
            //    genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "DOC_RND_REQ", Val = "true" });
            //    if (cbxInternalFlag.Checked)
            //    {
            //        genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "EXT_REQ", Val = "false" });
            //    }
            //    else
            //    {
            //        genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "EXT_REQ", Val = "true" });
            //    }                
            //    genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "DUPL_HANDL", Val = "CORE_WB_NO" });
            //    genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "SORT_BY", Val = "$INGEST_DATE,D" });
            //    genrc_rq.Add(new CdmGenericRequest_GenericRequestCriteria() { TyCd = "LANGUAGE", Val = "en" });

            //    bd.GenrcRq = genrc_rq.ToArray();

            //    List<CdmShipment_Shipment> shps = new List<CdmShipment_Shipment>();
            //    CdmShipment_Shipment shp = new CdmShipment_Shipment();
            //    shp.Id = txtAWBNumber.Text;
            //    List<CdmShipment_ShipmentTransaction> shp_trs = new List<CdmShipment_ShipmentTransaction>();
            //    CdmShipment_ShipmentTransaction shp_tr = new CdmShipment_ShipmentTransaction();
            //    List<CdmShipment_ShipmentCustomerDetail> scdtls = new List<CdmShipment_ShipmentCustomerDetail>();
            //    scdtls.Add(new CdmShipment_ShipmentCustomerDetail() { AccNo = txtAccountNumber.Text, CRlTyCd = "SP" });
            //    shp_tr.SCDtl = scdtls.ToArray();
            //    shp_trs.Add(shp_tr);
            //    shp.ShpTr = shp_trs.ToArray();
            //    List<CdmShipment_CustomsDocuments_ShipmentDocumentation> shpindocs = new List<CdmShipment_CustomsDocuments_ShipmentDocumentation>();
            //    CdmShipment_CustomsDocuments_ShipmentDocumentation shpindoc = new CdmShipment_CustomsDocuments_ShipmentDocumentation();
            //    shpindoc.DocTyCd = "POD";
            //    shpindocs.Add(shpindoc);
            //    shp.ShpInDoc = shpindocs.ToArray();
            //    shps.Add(shp);
            //    bd.Shp = shps.ToArray();
            //    req.Bd = bd;

            //    GloWS_Request = Common.XMLToString(req.GetType(), req);

            //    var glowsAuthData = Common.PrepareGlowsAuth("getePOD");

            //    gblDHLExpressePODClient client = new gblDHLExpressePODClient(new CustomBinding(glowsAuthData.Item2), glowsAuthData.Item1);
            //    client.ClientCredentials.UserName.UserName = glowsAuthData.Item3;
            //    client.ClientCredentials.UserName.Password = glowsAuthData.Item4;

            //    shipmentDocumentRetrieveRespMSG resp;

            //    try
            //    {
            //        resp = client.ShipmentDocumentRetrieve(req);
            //    }
            //    catch (Exception ex)
            //    {
            //        var text = ex.Message;
            //        label1.Text = label1.Text + ".";
            //        return;
            //    }

            //    XDocument xd = XDocument.Parse(client.RawResponse);
            //    List<XElement> pods = xd.Descendants(XName.Get("SDoc")).ToList();

            //    foreach(XElement pod in pods)
            //    {
            //        XElement img = pod.Descendants(XName.Get("Img")).First();
            //        string base64pod = img.Attribute(XName.Get("Img")).Value;
            //        byte[] binpod = System.Convert.FromBase64String(base64pod);
            //        if (null != (string)img.Attribute(XName.Get("ImgMineTy")))
            //        {
            //            string mimeType = img.Attribute(XName.Get("ImgMimeTy")).Value;
            //        }
            //        string tempFilename = System.IO.Path.GetTempFileName();
            //        System.IO.File.WriteAllBytes(tempFilename, binpod);

            //        System.Diagnostics.Process.Start(tempFilename);
            //    }

            //    //string jsonText = JsonConvert.SerializeXNode(xd);
            //    //dynamic dyn = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);

            //    //dynamic msg = ((dynamic)((IDictionary<string, object>) dyn).First().Value).MSG;

            //    //var msg2 = msg.MSG;

            //    //if (resp.DatTrErr.Any())
            //    //{
            //    //    MessageBox.Show("There was an error in tracking.");
            //    //    return;
            //    //}

            //    GloWS_Response = Common.XMLToString(resp.GetType(), resp);

            //    //var blah = new com.dhl.wsbexpress.epod.gblDHLExpressePODClient();

            //    //blah.ShipmentDocumentRetrieve(new shipmentDocumentRetrieveReqMSG()
            //    //{
            //    //    Hdr = new com.dhl.wsbexpress.epod.HDR
            //    //});
            //}
            //catch (Exception ex)
            //{
            //    var text = ex.Message;
            //    label1.Text = label1.Text + ".";
            //    return;
            //}
            //finally
            //{
            //    this.Enabled = true;
            //    this.UseWaitCursor = false;
            //    Cursor.Current = Cursors.Default;
            //}
        }
    }
}
