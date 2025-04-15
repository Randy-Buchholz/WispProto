//::SettingsRepository
/*
This file is used to override the default settings on parts.
*/

/* ********   Edit Text Base   ******** */
self.Settings.EditTextBase = class {
   static typeStyle = new Styling({
      Space: stylex.spaces.BlockSpace,
      Skin: stylex.edges.SingleRed
   });

   static States = class {
      static Unchanged = class {
         static Chroma = new Chroma({ Edge: "black", Back: "white" });
         static get stylette() { return this.Chroma.stylette; };
      };
      static Changing = class {
         static Chroma = new Chroma({ Focus: "purple" });
         static get stylette() { return this.Chroma.stylette; };
      };
      static Changed = class {
         static Chroma = new Chroma({ Edge: "red", Back: "lightgrey" });
         static get stylette() { return this.Chroma.stylette; };
      };
   };
};

/* ********   Person Contact   ******** */
//self.Settings.PersonContact = class {
//   static size = 600;
//   static cellGaps = 6;
//   static lineGaps = 6;
//};
