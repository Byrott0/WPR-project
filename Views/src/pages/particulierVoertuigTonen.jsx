import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "../styles/ParticulierVoertuigTonen.css";
import VoertuigRequestService from "../services/requests/VoertuigRequestService";
import JwtService from "../services/JwtService"; // Importeer de nieuwe JWT-service

const ParticulierVoertuigTonen = () => {
    const [voertuigen, setVoertuigen] = useState([]);
    const [filterType, setFilterType] = useState("auto");
    const [huurderId, setHuurderId] = useState(null);
    const navigate = useNavigate();

    // Haal het huurderID op via de API bij mount
    useEffect(() => {
        const fetchUserId = async () => {
            try {
                const userId = await JwtService.getUserId(); // Haal de gebruikers-ID op via de API
                if (userId) {
                    setHuurderId(userId);
                    console.log(huurderId);
                } else {
                    console.error("Huurder ID kon niet worden opgehaald via de API.");
                }
            } catch (error) {
                console.error("Fout bij het ophalen van de huurder ID:", error);
            }
        };

        fetchUserId();
    }, []);

    const handleChange = (event) => {
        setFilterType(event.target.value);
    };

    const handleVoertuigType = async () => {
        try {
            console.log("Voertuigen worden opgevraagd");
            const response = await VoertuigRequestService.getAll(filterType);
            setVoertuigen(response);
        } catch (error) {
            console.error("Het is niet gelukt om de voertuigtype op te halen", error);
        }
    };

    const handleSort = (criteria) => {
        const sortedVoertuigen = [...voertuigen].sort((a, b) => {
            if (a[criteria] < b[criteria]) return -1;
            if (a[criteria] > b[criteria]) return 1;
            return 0;
        });
        setVoertuigen(sortedVoertuigen);
    };

    const handleVoertuigClick = (voertuig) => {
        if (!huurderId) {
            alert("Huurder ID niet gevonden.");
            return;
        }
        navigate(
            `/huurVoertuig?kenteken=${voertuig.kenteken}&VoertuigID=${voertuig.voertuigId}&HuurderID=${huurderId}&SoortHuurder=Particulier`
        );
    };

    return (
        <div className="container">
            <div className="input-container">
                <select value={filterType} onChange={handleChange} className="input-field">
                    <option value="auto">Auto</option>
                    <option value="camper">Camper</option>
                    <option value="caravan">Caravan</option>
                </select>
                <button onClick={handleVoertuigType} className="button">
                    Voer voertuigType in
                </button>
            </div>
            <div className="button-container">
                <button onClick={() => handleSort("merk")} className="sort-button">
                    Sorteer op Merk
                </button>
                <button onClick={() => handleSort("model")} className="sort-button">
                    Sorteer op Model
                </button>
                <button onClick={() => handleSort("prijsPerDag")} className="sort-button">
                    Sorteer op Prijs
                </button>
                <button onClick={() => handleSort("bouwjaar")} className="sort-button">
                    Sorteer op Bouwjaar
                </button>
            </div>
            <table className="styled-table">
                <thead>
                    <tr>
                        <th>Merk</th>
                        <th>Model</th>
                        <th>Prijs Per Dag</th>
                        <th>Voertuig Type</th>
                        <th>Bouwjaar</th>
                        <th>Kenteken</th>
                        <th>Kleur</th>
                        <th>Beschikbaar</th>
                    </tr>
                </thead>
                <tbody>
                    {voertuigen.map((voertuig, index) => (
                        <tr key={index}>
                            <td
                                onClick={() => handleVoertuigClick(voertuig)}
                                style={{
                                    cursor: "pointer",
                                    color: "blue",
                                    textDecoration: "underline",
                                }}
                            >
                                {voertuig.merk}
                            </td>
                            <td>{voertuig.model}</td>
                            <td>{voertuig.prijsPerDag}</td>
                            <td>{voertuig.voertuigType}</td>
                            <td>{voertuig.bouwjaar}</td>
                            <td>{voertuig.kenteken}</td>
                            <td>{voertuig.kleur}</td>
                            <td>{voertuig.voertuigBeschikbaar ? "Ja" : "Nee"}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default ParticulierVoertuigTonen;
