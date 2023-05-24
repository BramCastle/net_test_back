export class Sessions {

    public static start(jsonSession : any) : boolean {
        if( jsonSession != undefined && jsonSession != null
            && jsonSession.id != undefined && jsonSession.id != null
            && jsonSession.user != undefined && jsonSession.user != null
            && jsonSession.token != undefined && jsonSession.token != null
            && jsonSession.expiration != undefined && jsonSession.expiration != null
            ) {
            
            this.setItem("id", jsonSession.id);
            this.setItem("user", jsonSession.user);
            this.setItem("token", jsonSession.token);
            this.setItem("expiration", jsonSession.expiration);

            return true;

        } else {
            //ELIMINAR SESION
            return false;
        }
    }

    public static getItem(key : string) {

        if (localStorage.getItem(key) !== undefined && localStorage.getItem(key) !== null) {
            try {
                let jsonValue : any = JSON.parse(localStorage.getItem(key) || '');
                return jsonValue;
            } catch (e) {
                return localStorage.getItem(key);
            }
        } else {
            return null;
        }
       
    }

    public static setItem(key : string, value : any) {
        try {
            let jsonValue : string = JSON.stringify(value);
            localStorage.setItem(key, jsonValue);
        } catch (e) {
            localStorage.setItem(key, value);
        }
    }

    public static validate() {
        if( Sessions.getItem("id") != null ) {
                return true;
        } else {
            return false;
        }
    }

    public static removeItem(key: string) {
        return localStorage.removeItem(key);
    }

    public static sessionDestroy() {
        var i = localStorage.length;
        while(i--) {
        var key = localStorage.key(i);
            this.removeItem(key || '');
        }
    }

    public static header() {
        let objReturn = {
            headers : {
              'Content-Type'      : 'application/json',
              'Authorization'     : 'Bearer ' + Sessions.getItem("token")
            }
        };

        return objReturn;
    }

    public static headerFormData() {
        let objReturn = {
            headers : {
              'Authorization'       : 'Bearer ' + Sessions.getItem("token")
            }
        };

        return objReturn;
    }

    public static headerFile() {
        let objReturn = {
            responseType : 'blob' as 'json',
            headers : {
                'Authorization'       : 'Bearer ' + Sessions.getItem("token")
            }
        };

        return objReturn;
    }

    public static headerFileNotToken() {
        let objReturn = {
            responseType : 'blob' as 'json'
        };

        return objReturn;
    }
}
