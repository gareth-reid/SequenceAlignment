using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bioinformatics.Web.Models;
using SequenceAligner.Engine.SequenceGrid;

namespace Bioinformatics.Web.Controllers
{
    public class SequenceAlignerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DnaGlobal()
        {
            var model = new SequenceAlignerModel()
                {
                    Sequence1 = "ccatcaaagagagaaagag",
                    Sequence2 = "gccatcaaagagagag"
                };
            return View(model);
        }

        public ActionResult DnaLocal()
        {
            return View();
        }

        public ActionResult ProteinGlobal()
        {
            return View();
        }

        public ActionResult ProteinLocal()
        {
            return View();
        }

        public ActionResult Execute(SequenceAlignerModel model)
        {
            var sequenceGrid = new SequenceGridNucleotide(model.Sequence1.ToCharArray(), model.Sequence2.ToCharArray());
            sequenceGrid.Initialize();
            sequenceGrid.FillMatrix();
            sequenceGrid.ExecuteTraceback();
            var alignedSequence = sequenceGrid.AlignedSequence().ToList();
            
            for (int i = 0; i < alignedSequence.Count(); i++)
            {
                model.Sequence1Aligned += alignedSequence[i].Key + " ";
            }
            for (int i = 0; i < alignedSequence.Count(); i++)
            {
                model.Sequence2Aligned += alignedSequence[i].Value + " ";
            }
            return PartialView("DnaGlobal", model);
             
        }
    }
}
