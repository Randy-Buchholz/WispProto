//::Part:Stylex
//:[Source
self.stylex = class Stylex {
   static spaces = class {
      static boxRelative = `position:relative; box-sizing:border-box;`
      static FlexSpace = this.boxRelative + `display:inline-flex;`;
      static BlockSpace = this.boxRelative + `display:block;`;
   };

   static edges = class {
      static SingleBlack = 'border:1px solid black;';
      static SingleRed = 'border:1px solid red;';
   };
};
//:]Source

