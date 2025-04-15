//::Part:SimpleSettings
//::Uses:CESTooling

//:[Source
self.Settings = class { }
//:]Source

//::Part:SimpleSheets
//:[Source
// Basic tools for elms and sheets
self.customRules = new CSSStyleSheet();
document.adoptedStyleSheets.push(customRules);
customRules.define = (tag, styles) => { customRules.insertRule(`${tag} {${flat(styles)}}`); };
customRules.defineMany = (tag, styles) => {
   styles.forEach(s => {
      customRules.insertRule(`${tag}${s[0] ?? ""} {${flat(s[1] ?? "")}}`);
   });
};
//:]Source

//::Part:SimpleElms
//:[Source
self.elm = class { };
self.regElm = (cls, stylettes) => {
   const tag = kebab(cls.name);
   customElements.define(tag, cls);
   elm[cls.name] = cls;
   let style = "";
   if ('typeStyle' in cls) {
      if (cls.typeStyle instanceof Styling) {
         style = cls.typeStyle.stylette;
      } else { style = clean(cls.typeStyle); };
   };
   style = unionRules(stylettes || '', style);
   customRules.define(tag, style);
   return elm[cls.name];
};
//:]Source

//::Part:Stereotyping
//:[Source
self.Stype = class StereotypeElement extends HTMLElement {
   #stype;
   get Stype() { return this.#stype; }
   set Stype(v) {
      this.#stype = v;
      this.setAttribute('stype', this.#stype);
   }
   stype(v) { this.Stype = v; return this; }
};

customRules.stype = (cls, type, stylettes) => {
    tag = kebab(cls.name);
    customRules.define(`${tag}[stype='${type}']`, stylettes);
};
//:]Source

