class RestHandler {
  url;
  port;
  constructor(url, port) {
    this.url = url;
    this.port = port;
  }

  /***
   *
   * @returns {RestHandler}
   */
  static getSingle(){
    return  new RestHandler("https://localhost", 7207);;

  }
  GetApiUrl() {
    return `${this.url}:${this.port}/api`;
  }

  async fetchGetSomething(args) {
    const response = fetch(`${this.GetApiUrl()}/${args}`);
    return await (await response).json();
  }

  async fetchDeleteSomething(args) {
    const response = fetch(`${this.GetApiUrl()}/${args}`, {
      method: "DELETE",
    });
    return (await response).status;
  }

  /**
   *
   * @returns {Promise<Array.<MegyeHandler>>}
   */
  async fetchGetMegyek() {
    return (await this.fetchGetSomething("Megye")).map(
      (x) => new MegyeHandler(x)
    );
  }

  /**
   *
   * @returns {Promise<MegyeHandler>}
   */
  async fetchGetMegye(id) {
    return (await this.fetchGetSomething("Megye/"+id));
  }

  async fetchDeleteMegye(id) {
    return this.fetchDeleteSomething(`Megye/${id}`);
  }

  /***
   *
   * @param {MegyeHandler}megye
   * @returns {Promise<void>}
   */
  async fetchEditMegye(megye){
    console.log(megye);
    const response = fetch(`${this.GetApiUrl()}/${'Megye'}`, {
      method: "POST",
      mode: 'cors', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
      body: JSON.stringify(megye) // body data type must match "Content-Type" header
       });
  }
  /***
   *
   * @param {MegyeHandler}megye
   * @returns {Promise<void>}
   */
  async fetchAddMegye(megye){
    const response = fetch(`${this.GetApiUrl()}/${'Megye'}`, {
      method: "PUT",
      mode: 'cors', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
      body: JSON.stringify(megye) // body data type must match "Content-Type" header
    });
  }

  async formEditMegye(e){
     await this.fetchEditMegye(RestHandler.getFormData($("#megyeEdit-form")))//.then( window.location.reload())

  }

  async formCreateMegye(){
    await this.fetchAddMegye(RestHandler.getFormData($("#megyeCreate-form")))//.then(window.location.reload())

  }
  static getFormData(form){
    var unindexed_array = form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function(n, i){
      indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
  }

}
