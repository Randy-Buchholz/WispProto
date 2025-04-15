//::Part:CESTooling
//:[Source
class CesTooling {
   static {
      self.kebab = (str) => str.replace(/([a-z])([A-Z])/g, '$1-$2').replace(/_/g, '-').toLowerCase();
      self.pascal = (str) => str.replace(/(^\w|-\w)/g, (match) => match.replace('-', '').toUpperCase());
      self.camel = (str) => str.toLowerCase().replace(/-([a-z])/g, (_, char) => char.toUpperCase());

      self.flat = (v) => Array.isArray(v) ? v.flat(Infinity).join('') : String(v);
      self.crunch = (v) => typeof v === 'string' ? v.trim().replace(/\s+/g, ' ') : String(v).trim().replace(/\s+/g, ' ');
      self.clean = (v) => crunch(flat(v));
      self.toRule = (prop, value) => value && prop ? `${prop}:${value};` : '';

      self.GetSettings = (pri, sec) => self.Settings[pri] ?? sec ?? (() => { throw new Error("Settings not found."); })();

      self.splitRules = (stylette) => {
         const map = new Map();
         const ruleSet = flat(stylette).split(';').filter(rule => rule.trim() !== '');
         for (let rule of ruleSet) {
            const [prop, value] = rule.split(':').map(s => s.trim());
            map.set(prop, value);
         };
         return map;
      };

      self.joinRules = (map) => {
         return Array.from(map).map(([prop, value]) => `${prop}:${value}`).join(';') + ';';
      };

      self.unionRules = (s1, s2) => {
         const m1 = splitRules(s1);
         const m2 = splitRules(s2);
         const resultMap = new Map([...m1, ...m2]);
         return joinRules(resultMap);
      };
   };

   static {
      self.applyStylette = (elm, stylette) => {
         if (!elm || !stylette) return;
         const stylette_ = clean(stylette);
         const rules = splitRules(stylette_);
         for (const rule of rules) {
            if (!rule[0] || !rule[1]) continue;
            elm.style[camel(rule[0])] = rule[1];
         }
      };
   };
};
//:]Source
