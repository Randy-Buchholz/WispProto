//::Part:ReadyCheck
//:[Source
class ReadyCheck {
   static eventListeners = [];
   static {
      if (document.body) {
         this.eventListeners.forEach(callback => callback());
         this.eventListeners = [];
      } else {
         new MutationObserver(() => {
            if (document.body) {
               this.eventListeners.forEach(callback => callback());
               this.eventListeners = [];
            }
         }).observe(document.documentElement, { childList: true });
      };
   };

   static onBody(callback) {
      this.eventListeners.push(callback);
      if (document.body) { callback(); };
   };
};
//:]Source

//:[Test
// Subscribe to the event
ReadyCheck.onBody(() => {
   console.log('Body is now available. Executing subscribed actions...');
   // Your logic here
});

ReadyCheck.onBody(() => {
   console.log('Another subscriber reacting to body availability.');
});
//:]Test
