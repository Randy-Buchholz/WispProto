//::Part:Tooling
//:[Source
class Tooling {
   // General Language Extensions
   static {
      self.Fault = (i) => { throw new Error(i); };
      self.Required = (i) => { return (i != null) ? i : Fault(`${i} Required`); };
      self.Default = (i, d) => { return (i != null) ? i : d; };
      self.Validate = (i, validationFn, errorMessage = 'Validation failed') => { return validationFn(i) ? i : Fault(errorMessage); };
      self.Exists = (v) => { return v !== null && typeof v !== 'undefined'; };
      self.NotExists = (v) => { return !(v !== null && typeof v !== 'undefined'); };
   };

   // Document Tools
   static {
      self.SetDocument = (content) => { const doc = document.open(); doc.write(content); doc.close(); };
      self.clearContent = (elm) => { while (elm.firstChild) { elm.removeChild(elm.firstChild); } };

      self.addToBody = (e) => document.body.appendChild(e);
      self.addManyToBody = (eg) => eg.forEach(e => addToBody(e));
      self.addTo = (p, e) => p.appendChild(e);
      self.addManyTo = (p, eg) => eg.forEach(e => addTo(p, e));

      self.addxToBody = (e) => { clearContent(document.body); document.body.appendChild(e); };
      self.addxManyToBody = (eg) => { clearContent(document.body); eg.forEach(e => addToBody(e)); };
      self.addxTo = (p, e) => { clearContent(p); p.appendChild(e); };
      self.addxManyTo = (p, eg) => { clearContent(p); eg.forEach(e => addTo(p, e)); };
   };
};
//:]Source