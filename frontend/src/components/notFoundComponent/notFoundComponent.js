import React from 'react';
import {Link} from 'react-router-dom';

export default function NotFoundComponent() {
    return (
        <div style={{textAlign: 'center', padding: '20px'}}>
            <h2>404 - Página no encontrada</h2>
            <p>Lo sentimos, la página que buscas no existe.</p>
            <Link to="/">
                <button style={{padding: '10px', marginTop: '10px', cursor: 'pointer'}}>
                    Volver al inicio
                </button>
            </Link>
        </div>
    );
};