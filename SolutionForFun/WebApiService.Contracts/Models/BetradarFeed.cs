using System;
using System.Collections.Generic;
using System.Text;

namespace Models.BetRadarFeed
{
    using System.Collections.Generic;
    using System.Xml.Serialization;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class BetradarStatisticsMatchSourceJoinData
    {

        private BetradarStatisticsMatchSourceJoinDataMatch[] matchesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Match", IsNullable = false)]
        public BetradarStatisticsMatchSourceJoinDataMatch[] Matches
        {
            get
            {
                return this.matchesField;
            }
            set
            {
                this.matchesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class BetradarStatisticsMatchSourceJoinDataMatch
    {

        private string idOfSourceField;

        private uint statisticsMatchIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string idOfSource
        {
            get
            {
                return this.idOfSourceField;
            }
            set
            {
                this.idOfSourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint statisticsMatchId
        {
            get
            {
                return this.statisticsMatchIdField;
            }
            set
            {
                this.statisticsMatchIdField = value;
            }
        }
    }
}