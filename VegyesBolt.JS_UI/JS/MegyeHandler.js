class MegyeHandler extends AbstractHandler {
  id;
  nev;
  szekhely;
  telepulesekSzama;
  nepesseg;
  terulet;
  constructor(jsonInput) {
    super();
    this.id = jsonInput.id;
    this.nev = new StandardField(jsonInput.nev);
    this.szekhely = new StandardField(jsonInput.szekhely);
    this.telepulesekSzama = new StandardField(jsonInput.telepulesekSzama);
    this.nepesseg = new StandardField(jsonInput.nepesseg);
    this.terulet = new StandardField(jsonInput.terulet);
    this._variablesToIterateThrough = [
      this.nev,
      this.szekhely,
      this.telepulesekSzama,
      this.nepesseg,
      this.nev,
    ];
  }
  static header = [
    "Név",
    "Székhely",
    "Települések Száma",
    "Népesség",
    "Terület",
  ];
}
