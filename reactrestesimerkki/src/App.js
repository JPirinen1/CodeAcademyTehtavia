import {useState, useEffect} from 'react';

const Asiakas = () =>
{

    const [query, setQuery] = useState(',');
    const [asiakkaat, setAsiakkaat] = useState([]);
    const [asiakastyypit, setAsiakastyypit] = useState([]);
    const [nimi, setNimi] = useState('');
    const [osoite, setOsoite] = useState('');
    const [asiakastyyppi, setAsiakastyyppi] = useState("0");
    const [loading, setLoading] = useState(false);
    const [ekahaku, setEkahaku] = useState(false);
    const [poistettavanid, setPoistettavanid] = useState(null);
    const [disabled, setDisabled] = useState("");
    const [uusinimi, setUusinimi] = useState('');
    const [uusiosoite, setUusiosoite] = useState('');
    const [uusipuhelin, setUusipuhelin] = useState('');
    const [uusiasiakastyyppi, setUusiasiakastyyppi] = useState("1");
    const [uusihenkilo, setUusihenkilo] = useState(',');
    const [uusiformi, setUusiformi] = useState(false);
    const [muokkaaformi, setMuokkaaformi] = useState(false);
    const [muokkaanimi, setMuokkaanimi] = useState('');
    const [muokkaaosoite, setMuokkaaosoite] = useState('');
    const [muokkaapuhelin, setMuokkaapuhelin] = useState('');
    const [muokkaaasiakastyyppi, setMuokkaaasiakastyyppi] = useState("");
    const [muokkaaid, setMuokkaaid] = useState('');
    const [muokkaahenkilo, setMuokkaahenkilo] = useState(',');
    const [eidataa, setEiDataa] = useState("");
    



    useEffect( () => 
    {
        const HaeAsiakas = async () =>
        {
            setEkahaku(true);
            setLoading(true);
            let response = await fetch("http://localhost:3004/asiakas?" + query);
            setLoading(false);
            setAsiakkaat(await response.json());
            if(asiakkaat == "")
            {
                setEiDataa("Annetuilla hakuehdoilla ei löytynyt dataa")
            }
        }

        if ( query != ',')
        {
            HaeAsiakas();
        }
    },[query]);

    useEffect( () => 
    {
        setTimeout(dataTyhjennys, 2000);
    },[eidataa]);

    useEffect( () => 
    {
        const HaeAsiakastyypit = async () =>
        {
            let response = await fetch("http://localhost:3004/asiakastyyppi");
            setAsiakastyypit(await response.json());
        }

        HaeAsiakastyypit();

    },[]);

    useEffect( () => 
    {
        const PoistaAsiakas = async () =>
        {
            await fetch("http://localhost:3004/asiakas/" + poistettavanid ,
            {method : "DELETE"});
            setQuery(query + " ");        
        }

        if ( poistettavanid != null)
        {    
            PoistaAsiakas();
        }
    },[poistettavanid]);

    useEffect( () => 
    {
        const LisaaAsiakas = async () =>
        {
            let body = JSON.stringify(uusihenkilo);
            await fetch("http://localhost:3004/asiakas" ,
            {
                method : "POST",
                headers: {'Content-Type': 'application/json'},
                body : body

            });
            setDisabled("");
            setQuery(query + " ");

        }

        if ( uusihenkilo != ',')
        {
            LisaaAsiakas();
        }
    },[uusihenkilo]);

    useEffect( () => 
    {
        const MuokkaaAsiakasta = async () =>
        {
            let body = JSON.stringify(muokkaahenkilo);
            await fetch("http://localhost:3004/asiakas/" + muokkaaid ,
            {
                method : "PUT",
                headers: {'Content-Type': 'application/json'},
                body : body

            });
            setDisabled("");
            setQuery(query + " ");
            setMuokkaaformi(false);


        }

        if ( muokkaahenkilo != ',')
        {
            MuokkaaAsiakasta();
        }
    },[muokkaahenkilo]);

    const dataTyhjennys = () =>
    {
        setEiDataa("");
    }

    const Hae = () =>
    {
        let q = "";

        if(nimi !== '')
        {
            q = "nimi=" + nimi + '&';
        }

        if(osoite !== '')
        {
            q = q + 'osoite=' + osoite + '&';
        }

        if(asiakastyyppi !== "0")
        {
            q= q + 'tyyppi_id=' + asiakastyyppi;
        }

        setQuery(q);
    }

    const rivit = asiakkaat.map((a,i) => <tr key={i}>
                                            <td>{a.id}</td>
                                            <td>{a.nimi}</td>
                                            <td>{a.osoite}</td>
                                            <td>{a.postinumero}</td>
                                            <td>{a.postitoimipaikka}</td>
                                            <td>{a.puhelinnro}</td>
                                            <td>{a.tyyppi_id}</td>
                                            <td>{a.tyyppi_selite}</td>
                                            <td><button onClick={() => Poista(a.id)}>Poista {a.id}</button></td>
                                            <td><button onClick={() => Lisaaformi(a)}>Muokkaa asiakasta {a.id}</button></td>
                                        </tr>)

    const Poista = (id) =>
    {
        const haeAsiakas = (asiakas) => asiakas.id == id;
        const asiakas = asiakkaat.find(haeAsiakas);

        let vastaus = window.confirm("Haluatko varmasti poistaa asiakkaan " + asiakas.nimi);
        if (vastaus)
        {
            setPoistettavanid(id);
        }
        
    }


    const Lisaaformi = (val) =>
    {
        setDisabled("disabled");

        if(val == "uusi")
        {
            setUusiformi(true);
            setMuokkaaformi(false);
        }
        else
        {
            setUusiformi(false);
            setMuokkaaformi(true);
            if(val.id)
            {
                setMuokkaanimi(val.nimi);
                setMuokkaaosoite(val.osoite);
                setMuokkaapuhelin(val.puhelinnro);
                setMuokkaaasiakastyyppi(val.tyyppi_id);
                setMuokkaaid(val.id);
            }

        }
    }

    const Peruuta = () =>
    {
        setDisabled("");
        setUusiformi(false);
        setMuokkaaformi(false);
    }

    const LisaaHenkilo = () =>
    {
        let unimi = "";
        let uosoite = "";
        let upuhelin = "";

        if(uusinimi !== '')
        {
            unimi = uusinimi;
        }

        if(uusiosoite !== '')
        {
            uosoite = uusiosoite;
        }

        if(uusipuhelin !== '')
        {
            upuhelin = uusipuhelin;
        }

        setUusihenkilo({nimi : unimi, osoite : uosoite, puhelinnro : upuhelin, tyyppi_id : uusiasiakastyyppi})

    }

    const MuokkaaHenkiloa = () =>
    {
        let mnimi = "";
        let mosoite = "";
        let mpuhelin = "";

        if(muokkaanimi !== '')
        {
            mnimi = muokkaanimi;
        }

        if(muokkaaosoite !== '')
        {
            mosoite = muokkaaosoite;
        }

        if(muokkaapuhelin !== '')
        {
            mpuhelin = muokkaapuhelin;
        }

        setMuokkaahenkilo({nimi : mnimi, osoite : mosoite, puhelinnro : mpuhelin, tyyppi_id : muokkaaasiakastyyppi})
    }


    const alasvetovalikko = asiakastyypit.map((a,i) => <option key={i} value={a.id}>{a.selite}</option>)

    return(
        <div>
            <fieldset disabled={disabled}>
                <label>Nimi
                    <input type="text" onChange={(e) => setNimi(e.target.value)}/>
                </label>
                <br/>
                <label>Osoite
                    <input type="text" onChange={(e) => setOsoite(e.target.value)}/>
                </label>
                <br/>
                <label>Asiakastyyppi
                <select onChange={(e) => setAsiakastyyppi (e.target.value)}>
                    <option value="0"></option>
                    {alasvetovalikko}
                </select>
                </label>
            <button onClick={() => Hae ()}>Hae</button>
            <button onClick={() => Lisaaformi ("uusi")}>Lisää uusi</button>
            </fieldset>        
            {uusiformi ? 
            <div>
                <br/>
                <br/>
                <form>
                    <label>
                        Nimi
                        <input type="text" onChange={(e) => setUusinimi(e.target.value)}/>
                    </label>
                    <br/>
                    <label>
                        Osoite
                        <input type="text" onChange={(e) => setUusiosoite(e.target.value)}/>
                    </label>
                    <br/>
                    <label>
                        Puhelin
                        <input type="text" onChange={(e) => setUusipuhelin(e.target.value)}/>
                    </label>
                    <br/>
                    <label>
                        Asiakastyyppi
                        <select onChange={(e) => setUusiasiakastyyppi (e.target.value)}>
                            {alasvetovalikko}
                        </select>
                    </label>
                </form>
                <br/>
                <button onClick={() =>LisaaHenkilo ()}>Tallenna</button>
                <button onClick={() => Peruuta()}>Peruuta</button>
                <br/><br/>
            </div>
    
            : muokkaaformi ? 
            <div>
                <br/>
                <br/>
                <form>
                    <label>
                        Nimi
                        <input type="text" value={muokkaanimi} onChange={(e) => setMuokkaanimi(e.target.value)}/>
                    </label>
                    <br/>
                    <label>
                        Osoite
                        <input type="text" value={muokkaaosoite} onChange={(e) => setMuokkaaosoite(e.target.value)}/>
                    </label>
                    <br/>
                    <label>
                        Puhelin
                        <input type="text" value={muokkaapuhelin} onChange={(e) => setMuokkaapuhelin(e.target.value)}/>
                    </label>
                    <br/>
                    <label>
                        Asiakastyyppi
                        <select value={muokkaaasiakastyyppi}  onChange={(e) => setMuokkaaasiakastyyppi (e.target.value)}>
                            {alasvetovalikko}
                        </select>
                    </label>
                </form>
                <br/>
                <button onClick={() =>MuokkaaHenkiloa ()}>Tallenna muutos</button>
                <button onClick={() => Peruuta ()}>Peruuta muokkaus</button>
                <br/><br/>
            </div>
            
            : null }
            {!ekahaku ? null : loading ? <p>Loading...</p> : asiakkaat == "" ? <p>{eidataa}</p> :
            <table>
                <tbody>
                    {rivit}
                </tbody>
            </table>
            }
        </div>
    )
}

export
{
    Asiakas
}