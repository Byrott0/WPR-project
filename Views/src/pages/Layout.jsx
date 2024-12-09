﻿import { Outlet, Link } from "react-router-dom";

const Layout = () => {
    return (
        <>
            <header>
                <nav className="navbar">
                    <Link to="/" className="nav-link">Startup</Link>&nbsp;
                    <Link to="/Home" className="nav-link">Info Pagina</Link>&nbsp;
                    <Link to="/instellingen" className="nav-link">Instellingen</Link>
                    <Link to="/abonnement" className="nav-link">Abonnement</Link>
                    <Link to="/zaakdashboard" className="nav-link">Zaak Dashboard</Link>
                    <Link to="/wagenparklogin" className="nav-link">Wagenpark Login</Link>
                    <Link to="/testPage" className="nav-link">TestPage</Link>
                </nav>
            </header>
            <main>
                <Outlet /> {/* Here the child route is rendered */}
            </main>
        </>
    );
};

export default Layout;
